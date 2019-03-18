using BaseballAPIproject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BaseballAPIproject.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult PlayerData(string Search)
        {
      
            List<PlayerData> FoundPlayers = new List<PlayerData>();
            HttpWebRequest request = WebRequest.CreateHttp("http://lookup-service-prod.mlb.com/json/named.search_player_all.bam?sport_code=\'mlb\'&active_sw=\'Y\'&name_part=\'"+ Search+"%25\'");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JObject BaseballJson = JObject.Parse(data);
            List<PlayerData> output = new List<PlayerData>();
            PlayerData pr = new PlayerData();
            
            string ID = BaseballJson["search_player_all"]["queryResults"]["row"][0]["player_id"].ToString();
            HttpWebRequest request2 = WebRequest.CreateHttp("http://lookup-service-prod.mlb.com/json/named.sport_hitting_tm.bam?league_list_id=\'mlb\'&game_type=\'R\'&season=\'2018\'&player_id=\'"+ID+"\'");
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader rd2 = new StreamReader(response2.GetResponseStream());
            string data2 = rd2.ReadToEnd();
            JObject BaseballJson2 = JObject.Parse(data2);
            //List<PlayerData> output2 = new List<PlayerData>();
            pr.ID = ID;
            //hello world
            pr.FirstName = BaseballJson["search_player_all"]["queryResults"]["row"][0]["name_first"].ToString();
            pr.LastName = BaseballJson["search_player_all"]["queryResults"]["row"][0]["name_last"].ToString();
            //pr.Age = BaseballJson2["search_player_all"]["queryResults"]["row"][""].ToString();
            pr.PA = (int)BaseballJson2["sport_hitting_tm"]["queryResults"]["row"]["tpa"];
            pr.SO = (int)BaseballJson2["sport_hitting_tm"]["queryResults"]["row"]["so"];
            pr.SB = (int)BaseballJson2["sport_hitting_tm"]["queryResults"]["row"]["sb"];
            pr.SLG = (double)BaseballJson2["sport_hitting_tm"]["queryResults"]["row"]["slg"];
            pr.AVG = (double)BaseballJson2["sport_hitting_tm"]["queryResults"]["row"]["avg"];
                   
            ViewBag.BaseballDate = pr;
            return View();

        }
    }
}