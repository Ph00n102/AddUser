using Newtonsoft.Json.Linq;
using HosxpUi.Models;
namespace HosxpUi.Controllers;

public class ServiceHelpers
{
    //private static Uri DataBaseAddress { get; set; } = new Uri("http://183.89.226.246:88");
    private static Uri DataBaseAddress { get; set; } = new Uri("http://172.16.200.202:8899");

    // public async static Task<List<Ward>> GetWardName()
    // {
    //     var param = new Dictionary<string, string>();
    //     //param.Add("Paramiter_HN", tempx);
    //     var content = new FormUrlEncodedContent(param);
    //     var client = new HttpClient();
    //     client.BaseAddress = DataBaseAddress;
    //     //var clientData = GetClientData();
    //     var response = await client.PostAsync("api/Ward/GetWardName", content);
    //     if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //     {
    //         var json = await response.Content.ReadAsStringAsync();

    //         return JArray.Parse(json).ToObject<List<Ward>>();

    //     }
    //     else return new List<Ward>();
    // }

    // public async static Task<List<Ipt>> GetIpts(string _wordnumber)
    // {
    //     var param = new Dictionary<string, string>();
    //     param.Add("_wordnumber", _wordnumber);
    //     var content = new FormUrlEncodedContent(param);
    //     var client = new HttpClient();
    //     client.BaseAddress = DataBaseAddress;
    //     var response = await client.PostAsync("api/Ward/GetWordDetail", content);
    //     if (response.StatusCode == System.Net.HttpStatusCode.OK)
    //     {
    //         var json = await response.Content.ReadAsStringAsync();

    //         return JArray.Parse(json).ToObject<List<Ipt>>();
    //     }
    //     else return new List<Ipt>();
    // }

//     public async static Task<List<LabInPatient>> Get_LabInNumberPatient(string paraAn)
//     {
//         var param = new Dictionary<string, string>();
//         param.Add("_paraAn", paraAn);

//         var content = new FormUrlEncodedContent(param);

//         var client = new HttpClient();
//         client.BaseAddress = DataBaseAddress;
//         var respont = await client.PostAsync("api/Opitemrece/GetLabOrderNumber", content);
//         if (respont.StatusCode == System.Net.HttpStatusCode.OK)
//         {
//             var json = await respont.Content.ReadAsStringAsync();
//             return JArray.Parse(json).ToObject<List<LabInPatient>>();
//         }
//         else return new List<LabInPatient>();

//     }
//     public async static Task<List<LabInPatient>> Get_LabInNumberPatient_OPD_IPD(string paraHN)
//     {
//         var param = new Dictionary<string, string>();
//         param.Add("_paraHn", paraHN);

//         var content = new FormUrlEncodedContent(param);

//         var client = new HttpClient();
//         client.BaseAddress = DataBaseAddress;
//         var respont = await client.PostAsync("api/Opitemrece/GetLabOrderNumber_IPD_OPD", content);
//         if (respont.StatusCode == System.Net.HttpStatusCode.OK)
//         {
//             var json = await respont.Content.ReadAsStringAsync();
//             return JArray.Parse(json).ToObject<List<LabInPatient>>();
//         }
//         else return new List<LabInPatient>();

//     }

//     public async static Task<List<LabDetailInPatient>> Get_LabDetailInPatient(string _paraLabOrdeNumber)
//     {
//         var param = new Dictionary<string, string>();
//         param.Add("_paraLabOrdeNumber", _paraLabOrdeNumber);

//         var content = new FormUrlEncodedContent(param);

//         var client = new HttpClient();
//         client.BaseAddress = DataBaseAddress;
//         var respont = await client.PostAsync("api/Opitemrece/GetLabDetail", content);
//         if (respont.StatusCode == System.Net.HttpStatusCode.OK)
//         {
//             var json = await respont.Content.ReadAsStringAsync();
//             return JArray.Parse(json).ToObject<List<LabDetailInPatient>>();
//         }
//         else return new List<LabDetailInPatient>();

//     }

//     public async static Task<List<Oapp>> GetOapps(string _paraHn)
//         {
//             var param = new Dictionary<string, string>();
//             param.Add("_paraHN", _paraHn);
//             var content = new FormUrlEncodedContent(param);
//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             var response = await client.PostAsync("api/EMR/EMRoapp", content);
//             if (response.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await response.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<Oapp>>();
//             }
//             else return new List<Oapp>();
//         }

//     public async static Task<List<Patient>> GetPatientDetail(string tempx)
//         {
//             var param = new Dictionary<string, string>();
//             param.Add("Paramiter_HN", tempx);
//             var content = new FormUrlEncodedContent(param);
//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             var response = await client.PostAsync("api/Patient/GetPatientDetail", content);
//             if (response.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await response.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<Patient>>();
//             }
//             else return new List<Patient>();
//         }
    
//     public async static Task<List<VstDate>> GetVstDate(string _paraHn)
//         {
//             var param = new Dictionary<string, string>();
//             param.Add("_paraHN", _paraHn);
//             var content = new FormUrlEncodedContent(param);
//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             var response = await client.PostAsync("api/Ovst/GetVSTDate", content);
//             if (response.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await response.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<VstDate>>();
//             }
//             else return new List<VstDate>();
//         }

//     public async static Task<List<Opdscreen>> eMROpdscreens(string _paraVN)
//         {
//             var param = new Dictionary<string, string>();
//             param.Add("_paraVN", _paraVN);
//             var content = new FormUrlEncodedContent(param);
//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             var response = await client.PostAsync("api/EMR/EMRopdscreen", content);
//             if (response.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await response.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<Opdscreen>>();
//             }
//             else return new List<Opdscreen>();
//         }

//     public async static Task<List<Ptnode>> GetNodePhoto(string _hn)
//         {
//             var param = new Dictionary<string, string>();
//             param.Add("_hn", _hn);
//             var content = new FormUrlEncodedContent(param);
//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             var response = await client.PostAsync("api/ward/GetPtnote", content);
//             if (response.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await response.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<Ptnode>>();
//             }
//             else return new List<Ptnode>();
//         }

//        public async static Task<List<X_RAY_REPORT>> Get_X_RAY_REPORT(string _Hn)
//         {
//             var param = new Dictionary<string, string>();
//             param.Add("_Hn", _Hn);
//             var content = new FormUrlEncodedContent(param);
//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             var response = await client.PostAsync("/api/EMR/Get_X_RAY_REPORT_DATA", content);
//             if (response.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await response.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<X_RAY_REPORT>>();
//             }
//             else return new List<X_RAY_REPORT>();
//         } 

//         public async static Task<List<Phama_mode_3_3_TAB>> Phama_Mode_3_3_TAB(string temp)
//         {
//             var param = new Dictionary<string, string>();
//             //  param.Add("_paraOrderNo", temp);
//             param.Add("_an", temp);
//             var content = new FormUrlEncodedContent(param);

//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             //var respont = await client.PostAsync("api/EMR/GMode3_2", content);
//             var respont = await client.PostAsync("/api/EMR/GeTMode3_3_TAB", content);
//             if (respont.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await respont.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<Phama_mode_3_3_TAB>>();
//             }
//             else return new List<Phama_mode_3_3_TAB>();

//         }

//         public async static Task<List<Phama_mode_3_3_>> Phama_Mode_3_3_s(string temp)
//         {
//             var param = new Dictionary<string, string>();
//             //  param.Add("_paraOrderNo", temp);
//             param.Add("_an", temp);
//             var content = new FormUrlEncodedContent(param);

//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             //var respont = await client.PostAsync("api/EMR/GMode3_2", content);
//             var respont = await client.PostAsync("/api/EMR/GeTMode3_3_", content);
//             if (respont.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await respont.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<Phama_mode_3_3_>>();
//             }
//             else return new List<Phama_mode_3_3_>();

//         }

//         public async static Task<List<OpitemreceOut>> Get_EMRdispenseOPD(string _paraVn)
//         {
//             var param = new Dictionary<string, string>();
//             param.Add("_paraVn", _paraVn);

//             var content = new FormUrlEncodedContent(param);

//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             var respont = await client.PostAsync("api/Opitemrece/GetOPD", content);
//             if (respont.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await respont.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<OpitemreceOut>>();
//             }
//             else return new List<OpitemreceOut>();

//         }

//         public async static Task<List<OutLabData>> Get_OutLabData(string _lab_order_number)
//         {
//             var param = new Dictionary<string, string>();
//             param.Add("_lab_order_number", _lab_order_number);

//             var content = new FormUrlEncodedContent(param);

//             var client = new HttpClient();
//             client.BaseAddress = DataBaseAddress;
//             var respont = await client.PostAsync("api/Opitemrece/Get_Out_Lab", content);
//             if (respont.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                 var json = await respont.Content.ReadAsStringAsync();
//                 return JArray.Parse(json).ToObject<List<OutLabData>>();
//             }
//             else return new List<OutLabData>();

//         }

//         private static HttpClient GetClientData()
//         {
//             var clientData = new HttpClient();
//             clientData.BaseAddress = DataBaseAddress;
//             return clientData;
//         }

//         //=========================LoginModels======================//
//         public static async Task<Opduser> Authen(string loginname, string password)
//         {

//             var param = new Dictionary<string, string>();
//             param.Add("Loginname", loginname);
//             param.Add("Passweb", password);


//             var content = new FormUrlEncodedContent(param);

//             var clientData = GetClientData();
//             var response = await clientData.PostAsync("api/Opduser/Auth", content);
//             if (response.StatusCode == System.Net.HttpStatusCode.OK)
//             {
//                  var json = await response.Content.ReadAsStringAsync();
//                 return JObject.Parse(json).ToObject<Opduser>();
//             }
//             else return null;
//         }



}