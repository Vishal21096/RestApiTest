using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

//public class person
//{
//    public int id { get; set; }
//    public string username { get; set; }
//    public string password { get; set; }
//    public string first_name { get; set; }
//    public string last_name{ get; set; }
//    public string  email{ get; set; }

//}

//public class class1 { 

//static void Main(string[] args)
//{
//    using (var client = new HttpClient())
//    {
//        person p = new person { username = "Vishal1", password = "saini", first_name = "Vishal", last_name = "Saini", email = "vishal1@qainfotech.com" };
//        client.BaseAddress = new Uri("https://code-riddler.herokuapp.com/api/v1/candidates/");
//        var response = client.PostAsJsonAsync("", p).Result;
//        if (response.IsSuccessStatusCode)
//        {
//            var readTask = response.Content.ReadAsAsync<person>();
//            readTask.Wait();
//            var Details = readTask.Result;
//            Console.WriteLine("UserName {0} Password {1} with Id: {2}", Details.UserName, Details.Password, Details.Id);
//            Console.Write("Success");
//        }
//        else
//            Console.Write("Error");
//    }

//}
//}

//namespace ConsoleApp4
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            var obtainsessionkey = new SessionModel { candidate = 119 };

//            HttpClient Hc = new HttpClient();

//            Hc.BaseAddress = new Uri("https://code-riddler.herokuapp.com/api/v1/testsessions/");

//            var byteArray = Encoding.ASCII.GetBytes("SainiVishal:Vishal01");
//            Hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
//            var postTask = Hc.PostAsJsonAsync<SessionModel>("", obtainsessionkey);
//            postTask.Wait();
//            var saveData = postTask.Result;
//            if (saveData.IsSuccessStatusCode)
//            {
//                var readTask = saveData.Content.ReadAsAsync<SessionModel>();
//                readTask.Wait();
//                var Details = readTask.Result;
//                Console.WriteLine("id {0} candidate {1} with sessionkey: {2}", Details.candidate, Details.id, Details.session_key);

//            }
//            else
//            {
//                Console.WriteLine(saveData.StatusCode);
//            }
//        }

//    }
//}


namespace ConsoleApp4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task T = new Task(ApiCall);
            T.Start();
            Console.WriteLine("Json data........");
            Console.ReadLine();
        }
        static async void ApiCall()
        {
            var Logic1_list = new List<int>();
            //var obtainsessionkey = new SessionModel { candidate = 119 };
            using (var client = new HttpClient())
            {
                //var byteArray = Encoding.ASCII.GetBytes("SainiVishal:Vishal01");
                //    var accessToken = Convert.ToBase64String(
                //System.Text.ASCIIEncoding.ASCII.GetBytes(
                //   $"{"SainiVishal"}:{"Vishal01"}"));
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer" + accessToken);
                //HttpClient Hc = new HttpClient();

                client.BaseAddress = new Uri("https://code-riddler.herokuapp.com/api/v1/testsessions/");

                var byteArray = Encoding.ASCII.GetBytes("SainiVishal:Vishal01");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));


                HttpResponseMessage response = await client.GetAsync("https://code-riddler.herokuapp.com/api/v1/challenges/get_challenge/");

                //var response2 = await client.GetStringAsync("https://code-riddler.herokuapp.com/api/v1/challenges/get_challenge/");
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken.ToString());
                //response.EnsureSuccessStatusCode();

                using (HttpContent content = response.Content)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(responseBody.Substring(0, 50) + "........");

                    var articles = JsonConvert.DeserializeObject<GetQuestion>(responseBody);

                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", articles.id, articles.question_text, articles.test_input.text, articles.sample_input.text, articles.sample_output.a, articles.sample_output.e, articles.sample_output.i, articles.sample_output.o, articles.sample_output.u);
                    Logic1_list = new Class2().logic_1(articles.test_input.text);
                }
                client.Dispose();
                using (var clientPost = new HttpClient())
                {
                    var byteArrayPost = Encoding.ASCII.GetBytes("SainiVishal:Vishal01");
                    clientPost.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var ans = new answer();
                    ans.test_session = 119; ans.output = new Sample_Output();             
                    ans.output.a = Logic1_list[0]; ans.output.e = Logic1_list[1]; ans.output.i = Logic1_list[2]; ans.output.o = Logic1_list[3]; ans.output.u = Logic1_list[4]; ans.challenge = 4;
                    clientPost.BaseAddress = new Uri("https://code-riddler.herokuapp.com/api/v1/testsessionchallenges/output/");
                    HttpResponseMessage respo = await clientPost.PostAsJsonAsync("",ans);                    
                    if (respo.IsSuccessStatusCode)
                    {
                        Console.Write("inserted");
                    }
                    else
                        Console.Write("Error");

                }
            }
        }
    }
}

