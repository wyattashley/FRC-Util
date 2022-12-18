using FRC_Utility_Software.Display_Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FRC_Utility_Software
{
    public partial class BlueAllianceAPI : Form
    {

        private static HttpClient httpClient = new HttpClient();
        private string baseAddress = "https://www.thebluealliance.com/api/v3";
        private string currentYear = "2022";

        public BlueAllianceAPI()
        {
            InitializeComponent();

            httpClient.BaseAddress = new Uri("http://www.thebluealliance.com/api/v3/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("X-TBA-Auth-Key", "MVp1kdKjqXGVSe35f3xff1X2gjVSuzAWnMf8hAZRHakU4huVqn1vIaYB6KyfjvV3");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("MVp1kdKjqXGVSe35f3xff1X2gjVSuzAWnMf8hAZRHakU4huVqn1vIaYB6KyfjvV3");
        }

        /*
        [
          {
            "key": "string",
            "team_number": 0,
            "nickname": "string",
            "name": "string",
            "city": "string",
            "state_prov": "string",
            "country": "string"
          }
        ]
        */
        private List<Dictionary<string, string>> getTeamsInEvent(string eventKey)
        {
            string result = makeRequest("/event/" + eventKey + "/teams/simple");
            return deserializeList(result);
        }

        private string makeRequest(string link)
        {
            HttpRequestMessage message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri(baseAddress + link);

            HttpResponseMessage response = httpClient.Send(message);

            if (!response.IsSuccessStatusCode)
                MessageBox.Show("Failed to pull data");

            using (var streamReader = new StreamReader(response.Content.ReadAsStream()))
            {
                var responseText = streamReader.ReadToEnd();
                return responseText;
            }
        }

        private List<Dictionary<string, string>> deserializeList(string value)
        {
            return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(value);
        }

        private void loadFIMEvents_Click(object sender, EventArgs e)
        {
            eventList.Items.Clear();
            List<EventLite> events = JsonConvert.DeserializeObject<List<EventLite>>(makeRequest("/district/" + currentYear + "fim/events/simple"));
            eventList.Items.AddRange(events.ToArray());            
            //foreach (EventLite a in events) {
            //    eventList.Items.Add(a.name);
            //}
            MessageBox.Show("FIM Data Loaded");
        }

        private void loadAllEvents_Click(object sender, EventArgs e)
        {
            eventList.Items.Clear();
            List<EventLite> events = JsonConvert.DeserializeObject<List<EventLite>>(makeRequest("/events/" + currentYear + "/simple"));
            eventList.Items.AddRange(events.ToArray());
            MessageBox.Show("Blue Alliance Data Loaded");
        }

        private void loadScoreStates_Click(object sender, EventArgs e)
        {
            List<Match> matches = JsonConvert.DeserializeObject<List<Match>>(makeRequest("/event/" + ((EventLite) eventList.SelectedItem).key + "/matches"));
            
            Score averageWinner = new Score();
            Score averageLoser = new Score();
            
            foreach (Match match in matches)
            {
                if(match.winning_alliance.Equals("blue"))
                {
                    averageWinner.addBy(match.score_breakdown.blue);
                    averageLoser.addBy(match.score_breakdown.red);
                } else if (match.winning_alliance.Equals("red"))
                {
                    averageWinner.addBy(match.score_breakdown.red);
                    averageLoser.addBy(match.score_breakdown.blue);
                }
            }

            averageWinner.devideByConstant(matches.Count());
            averageLoser.devideByConstant(matches.Count());

            outputDialog.Text = "Winner: \n" + averageWinner.ToString() + "\nLoser: \n" + averageLoser.ToString();
            MessageBox.Show("Data Loaded");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Series points = new Series();
            points.ChartArea = "ChartArea1";
            points.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            points.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            points.IsVisibleInLegend = true;
            points.Name = "Points";
            points.Color = Color.DarkRed;

            points.Points.AddXY(10, 50);
            points.Points.AddXY(8, 7);
            points.Points.AddXY(14, 6);
            points.Points.AddXY(19, 2);
            points.Points.AddXY(8, 2);
            points.Points.AddXY(8, 20);

            (new GraphicalDisplay(new Series[]{points})).Show();
        }

        private void LoadTeam_Click(object sender, EventArgs e)
        {
            string teamKey = "frc" + TeamNumberNumeric.Value.ToString();
            string year = "2022";

            List<EventLite> events = JsonConvert.DeserializeObject<List<EventLite>>(makeRequest("/team/" + teamKey + "/events/" + year + "/simple"));

            List<Match> teamMatches = JsonConvert.DeserializeObject<List<Match>>(makeRequest("/team/" + teamKey + "/event/" + events[1].key + "/matches"));
            List<Match> eventMatches = JsonConvert.DeserializeObject<List<Match>>(makeRequest("/event/" + events[1].key + "/matches"));

            int teamMatchAverage = 0;
            int eventMatchAverage = 0;
            double eventMatchStandardDeviation = 0;

            foreach (Match match in teamMatches)
            {
                if(match.alliances.blue.team_keys.Contains(teamKey))
                {
                    teamMatchAverage += int.Parse(match.score_breakdown.blue.endgameRobot2);
                } else
                {
                    teamMatchAverage += int.Parse(match.score_breakdown.red.endgameRobot2);
                }
            }

            foreach (Match match in eventMatches)
            {
                eventMatchAverage += int.Parse(match.score_breakdown.blue.endgameRobot2);
                eventMatchAverage += int.Parse(match.score_breakdown.red.endgameRobot2);
            }

            teamMatchAverage /= teamMatches.Count();
            eventMatchAverage /= eventMatches.Count();

            foreach (Match match in eventMatches)
            {
                eventMatchStandardDeviation += Math.Pow((double) int.Parse(match.score_breakdown.blue.endgameRobot2) - eventMatchAverage, 2.0);
                eventMatchStandardDeviation += Math.Pow((double) int.Parse(match.score_breakdown.red.endgameRobot2) - eventMatchAverage, 2.0);
            }

            eventMatchStandardDeviation /= eventMatches.Count() - 1;
            eventMatchStandardDeviation = Math.Sqrt(eventMatchStandardDeviation);

            double zClimbScore = (teamMatchAverage - eventMatchAverage) / (eventMatchStandardDeviation / Math.Sqrt(eventMatches.Count()));

            outputDialog.Text += "Event Key: " + events[1].key + "\n";
            outputDialog.Text += "Event Name: " + events[1].name + "\n";
            outputDialog.Text += "Z Score: " + zClimbScore;
        }
    }

    public class EventLite
    {
        //public string city { get; set; }
        //public string country { get; set; }
        //public Dictionary<string, string> district { get; set; }
        //public string end_date { get; set; }
        public string event_code { get; set; }
        public int event_type { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        //public string start_date { get; set; }
        //public string state_prov { get; set; }
        //public int year { get; set; }

        override
        public string ToString()
        {
            return name + " (" + key + ")";
        }
    }

    public class Match
    {
        public Alliances alliances { get; set; }
        public ScoreBreakdown score_breakdown { get; set; }
        public string comp_level { get; set; }
        public int matchNumber { get; set; }
        public string winning_alliance { get; set; }

    }

    public class ScoreBreakdown
    {
        public Score blue { get; set; }
        public Score red { get; set; }
    }

    public class Score
    {
        public float adjustPoints { get; set; }
        public float autoCargoLowerBlue { get; set; }
        public float autoCargoLowerFar { get; set; }
        public float autoCargoLowerNear { get; set; }
        public float autoCargoLowerRed { get; set; }
        public float autoCargoPoints { get; set; }
        public float autoCargoTotal { get; set; }
        public float autoCargoUpperBlue { get; set; }
        public float autoCargoUpperFar { get; set; }
        public float autoCargoUpperNear { get; set; }
        public float autoCargoUpperRed { get; set; }
        public float autoPoints { get; set; }
        public float autoTaxiPoints { get; set; }
        public bool cargoBonousRankingPoint { get; set; }
        public float endgamePoints { get; set; }
        public string endgameRobot1 { get; set; }
        public string endgameRobot2 { get; set; }
        public string endgameRobot3 { get; set; }
        public float foulCount { get; set; }
        public float foulPoints { get; set; }
        public bool hangarBonusRankingPoint { get; set; }
        public float matchCargoTotal { get; set; }
        public bool quintetAchieved { get; set; }
        public float rp { get; set; }
        public string taxiRobot1 { get; set; }
        public string taxiRobot2 { get; set; }
        public string taxiRobot3 { get; set; }
        public float techFoulCount { get; set; }
        public float teleopCargoLowerBlue { get; set; }
        public float teleopCargoLowerFar { get; set; }
        public float teleopCargoLowerNear { get; set; }
        public float teleopCargoLowerRed { get; set; }
        public float teleopCargoPoints { get; set; }
        public float teleopCargoTotal { get; set; }
        public float teleopCargoUpperBlue { get; set; }
        public float teleopCargoUpperFar { get; set; }
        public float teleopCargoUpperNear { get; set; }
        public float teleopCargoUpperRed { get; set; }
        public float teleopPoints { get; set; }
        public float totalPoints { get; set; }

        private double addToAverage(double average, int size, double value)
        {
            return (size * average + value) / (size + 1);
        }
        public void addBy(Score score)//, int size, int value)
        {
            //addToAverage(adjustPoints += score.adjustPoints;
            autoCargoLowerBlue += score.autoCargoLowerBlue;
            autoCargoLowerFar += score.autoCargoLowerFar;
            autoCargoLowerNear += score.autoCargoLowerNear;
            autoCargoLowerRed += score.autoCargoLowerRed;
            autoCargoPoints += score.autoCargoPoints;
            autoCargoTotal += score.autoCargoTotal;
            autoCargoUpperBlue += score.autoCargoUpperBlue;
            autoCargoUpperFar += score.autoCargoUpperFar;
            autoCargoUpperNear += score.autoCargoUpperNear;
            autoCargoUpperRed += score.autoCargoUpperRed;
            autoPoints += score.autoPoints;
            autoTaxiPoints += score.autoTaxiPoints;
            //cargoBonusRankingPoint
            endgamePoints += score.endgamePoints;
            //endgameRobot1
            foulCount += score.foulCount;
            foulPoints += score.foulPoints;
            //hangarBonusRankingPoint
            matchCargoTotal += score.matchCargoTotal;
            //quintetAchieved
            rp += score.rp;
            techFoulCount += score.techFoulCount;
            teleopCargoLowerBlue += score.teleopCargoLowerBlue;
            teleopCargoLowerFar += score.teleopCargoLowerFar;
            teleopCargoLowerNear += score.teleopCargoLowerRed;
            teleopCargoPoints += score.teleopCargoPoints;
            teleopCargoTotal += score.teleopCargoTotal;
            teleopCargoUpperBlue += score.teleopCargoUpperBlue;
            teleopCargoUpperFar += score.teleopCargoUpperFar;
            teleopCargoUpperNear += score.teleopCargoUpperNear;
            teleopCargoUpperRed += score.teleopCargoUpperRed;
            teleopPoints += score.teleopPoints;
            totalPoints += score.totalPoints;
        }

        public void devideByConstant(float constant)
        {
            adjustPoints /= constant;
            autoCargoLowerBlue /= constant;
            autoCargoLowerFar /= constant;
            autoCargoLowerNear /= constant;
            autoCargoLowerRed /= constant;
            autoCargoPoints /= constant;
            autoCargoTotal /= constant;
            autoCargoUpperBlue /= constant;
            autoCargoUpperFar /= constant;
            autoCargoUpperNear /= constant;
            autoCargoUpperRed /= constant;
            autoPoints /= constant;
            autoTaxiPoints /= constant;
            //cargoBonusRankingPoint
            endgamePoints /= constant;
            //endgameRobot1
            foulCount /= constant;
            foulPoints /= constant;
            //hangarBonusRankingPoint
            matchCargoTotal /= constant;
            //quintetAchieved
            rp /= constant;
            techFoulCount /= constant;
            teleopCargoLowerBlue /= constant;
            teleopCargoLowerFar /= constant;
            teleopCargoLowerNear /= constant;
            teleopCargoPoints /= constant;
            teleopCargoTotal /= constant;
            teleopCargoUpperBlue /= constant;
            teleopCargoUpperFar /= constant;
            teleopCargoUpperNear /= constant;
            teleopCargoUpperRed /= constant;
            teleopPoints /= constant;
            totalPoints /= constant;
        }

        override
        public string ToString()
        {
            StringBuilder value = new StringBuilder();
            value.Append("\tAdjusted Points: " + adjustPoints);
            value.Append("\n\tAuto Cargo Lower Blue: " + autoCargoLowerBlue);
            value.Append("\n\tAuto Cargo Lower Far: " + autoCargoLowerFar);
            value.Append("\n\tAuto Cargo Lower Near: " + autoCargoLowerNear);
            value.Append("\n\tAuto Cargo Lower Red: " + autoCargoLowerRed);
            value.Append("\n\tAuto Cargo Points: " + autoCargoPoints);
            value.Append("\n\tAuto Cargo Total: " + autoCargoTotal);
            value.Append("\n\tAuto Gargo Upper Blue: " + autoCargoUpperBlue);
            value.Append("\n\tAuto Cargo Upper Far: " + autoCargoUpperFar);
            value.Append("\n\tAuto Cargo Upper Near: " + autoCargoUpperNear);
            value.Append("\n\tAuto Cargo Upper Red: " + autoCargoUpperRed);
            value.Append("\n\tAuto Points: " + autoPoints);
            value.Append("\n\tAuto Taxi Points: " + autoTaxiPoints);
            value.Append("\n\tEndgame Points: " + endgamePoints);
            value.Append("\n\tFoul Count: " + foulCount);
            value.Append("\n\tFoul Points: " + foulPoints);
            value.Append("\n\tMatchCargoTotal: " + matchCargoTotal);
            value.Append("\n\tRP: " + rp);
            value.Append("\n\tTech Foul Count: " + techFoulCount);
            value.Append("\n\tTeleOp Cargo Lower Blue: " + teleopCargoLowerBlue);
            value.Append("\n\tTeleOp Cargo Lower Far: " + teleopCargoLowerFar);
            value.Append("\n\tTeleOp Cargo Lower Near: " + teleopCargoLowerNear);
            value.Append("\n\tTeleOp Cargo Points: " + teleopCargoPoints);
            value.Append("\n\tTeleOp Cargo Total: " + teleopCargoTotal);
            value.Append("\n\tTeleOp Cargo Upper Blue: " + teleopCargoUpperBlue);
            value.Append("\n\tTeleOp Cargo Upper Far: " + teleopCargoUpperFar);
            value.Append("\n\tTeleOp Cargo Upper Near: " + teleopCargoUpperNear);
            value.Append("\n\tTeleOp Cargo Upper Red: " + teleopCargoUpperRed);
            value.Append("\n\tTeleOp Points: " + teleopPoints);
            value.Append("\n\tTotal Points: " + totalPoints);

            return value.ToString();
        }
    }

    public class Alliances
    {
        public Alliance red { get; set; }
        public Alliance blue { get; set; }
    }

    public class Alliance
    {
        public int score;
        public List<string> team_keys;
    }
}
