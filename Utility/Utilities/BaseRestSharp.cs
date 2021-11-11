//using Common.Interface;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;

//namespace Utility.Utilities
//{
//    public class BaseRestSharp : IHttpConnect
//    {

//        RestClient client;
//        private List<Parameter> Params;
//        private Parameter parameter;
//        private readonly IJsonConvertCommon jsonConvert;

//        public IRestResponse Response { get { return response; } }
//        IRestResponse response;

//        //Dictionary<string, string> Cookie;

//        public BaseRestSharp(string url)
//        {
//            client = new RestClient(url);
//            jsonConvert = new JsonConvertCommon();

//        }


//        public void AddParametr(string Name, object Value, ParameterType Type)
//        {
//            if (Params == null) Params = new List<Parameter>();
//            parameter = new Parameter(Name, Value, Type);
//            Params.Add(parameter);
//        }

//        public void AddHeader(string Name, object Value)
//        {
//            if (Params == null) Params = new List<Parameter>();
//            Params.Add(new Parameter(Name, Value, ParameterType.HttpHeader));

//        }

//        //public void AddCookie(string name, string value)
//        //{
//        //    if (Cookie == null)
//        //        Cookie = new Dictionary<string, string>();

//        //    Cookie.Add(name, value);
//        //}

//        //public void SetCookie(RestRequest request)
//        //{
//        //    if (Cookie != null)
//        //    {
//        //        foreach (var item in Cookie)
//        //        {
//        //            request.AddCookie(item.Key, item.Value);
//        //        }
//        //    }

//        //}

//        public T Connecting<T>(string Url, ConnectType connectType, NameValueCollection Header, object Data)
//        {


//            try
//            {
//                var request = new RestRequest(Url);
//                if (Header != null)
//                {
//                    for (int i = 0; i < Header.AllKeys.Length; i++)
//                    {
//                        string HeaderValue = Header.GetValues(i).First();
//                        string HeaderKey = Header.AllKeys.Skip(i).FirstOrDefault();
//                        request.AddHeader(HeaderKey, HeaderValue);
//                    }
//                }

//                //SetCookie(request);

//                response = null;
//                if (connectType == ConnectType.POST)
//                {

//                    if (Params != null)
//                    {


//                        //foreach (var item in Params)
//                        //{
//                        //    Request.AddParameter
//                        //}

//                        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
//                        //Request.JsonSerializer.ContentType = "application/x-www-form-urlencoded";
//                        request.Parameters.AddRange(Params);

//                    }

//                    else
//                        request.AddJsonBody(Data);
//                    response = client.Post(request);
//                }
//                else
//                {
//                    response = client.Get(request);
//                }


//                if (Response.StatusCode == HttpStatusCode.OK)
//                {
//                    try
//                    {
//                        if (jsonConvert.TryDeserializeObject<T>(Response.Content))
//                        {
//                            return jsonConvert.DeserializeObject<T>(Response.Content);

//                        }


//                        // return new Core.ViewModel.Response { result = 1, message = Newtonsoft.Json.JsonConvert.DeserializeObject<Core.ViewModel.Response>(ReturnData.Content).message };
//                        throw new AppException(Response.Content);
//                    }
//                    catch (Exception)
//                    {
//                        throw new AppException(Response.Content);
//                    }

//                }
//                else
//                {
//                    try
//                    {
//                        throw new AppException(Response.Content);
//                    }
//                    catch (Exception)
//                    {
//                        throw new AppException(Response.Content);
//                    }

//                }
//            }
//            catch (Exception e)
//            {

//                throw new AppException(e.StackTrace);
//            }

//        }

//        public T Connecting<T>(string Url, ConnectType connectType, object Data)
//        {


//            try
//            {
//                var request = new RestRequest(Url);
//                if (Params != null && Params.Where(t => t.Type == ParameterType.HttpHeader).Any())
//                {
//                    foreach (var item in Params.Where(t => t.Type == ParameterType.HttpHeader).ToList())
//                    {
//                        request.AddHeader(item.Name, item.Value.ToString());
//                    }
//                }

//                //SetCookie(request);

//                if (Data != null)
//                    request.AddJsonBody(Data);

//                if (Params != null && Params.Where(t => t.Type == ParameterType.RequestBody).Any())
//                {
//                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
//                    var paramsw = Params.Where(t => t.Type == ParameterType.RequestBody).Select(t => t.Name).ToList();
//                    string StrParam = null;
//                    foreach (var item in Params.Where(t => t.Type == ParameterType.RequestBody).ToList())
//                    {
//                        if (!string.IsNullOrEmpty(StrParam)) StrParam += "&";
//                        StrParam += $"{item.Name}={item.Value}";
//                    }

//                    request.Parameters.Add(new Parameter("undefined", StrParam, ParameterType.RequestBody));
//                }


//                response = null;
//                switch (connectType)
//                {
//                    case ConnectType.GET:
//                        response = client.Get(request);
//                        break;
//                    case ConnectType.POST:
//                        response = client.Post(request);
//                        break;
//                    case ConnectType.DELETE:
//                        response = client.Delete(request);
//                        break;
//                    case ConnectType.PUT:
//                        response = client.Put(request);
//                        break;
//                    default:
//                        break;
//                }

//                if (Response == null)
//                    throw new AppException("پاسخی مناسب از سرویس دهنده دریافت نشد");

//                if (Response.StatusCode == HttpStatusCode.OK)
//                {
//                    try
//                    {
//                        if (jsonConvert.TryDeserializeObject<T>(Response.Content))
//                        {
//                            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Response.Content); // return new Core.ViewModel.Response { result = 1, message = Newtonsoft.Json.JsonConvert.DeserializeObject<Core.ViewModel.Response>(ReturnData.Content).message };

//                        }
//                        throw new AppException(Response.Content);

//                    }
//                    catch (Exception e)

//                    {
//                        throw new AppException(e.Message);
//                    }
//                }
//                else
//                {
//                    throw new AppException(Response.Content);
//                }
//            }
//            catch (Exception e)
//            {

//                throw new AppException(e.Message);

//            }

//        }
//        public T Connecting<T>(string Url, ConnectType connectType)
//        {


//            try
//            {
//                var request = new RestRequest(Url);
//                if (Params != null && Params.Where(t => t.Type == ParameterType.HttpHeader).Any())
//                {
//                    foreach (var item in Params.Where(t => t.Type == ParameterType.HttpHeader).ToList())
//                    {
//                        request.AddHeader(item.Name, item.Value.ToString());
//                    }
//                }

//                //SetCookie(request);


//                if (Params != null && Params.Where(t => t.Type == ParameterType.RequestBody).Any())
//                {
//                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
//                    var paramsw = Params.Where(t => t.Type == ParameterType.RequestBody).Select(t => t.Name).ToList();
//                    string StrParam = null;
//                    foreach (var item in Params.Where(t => t.Type == ParameterType.RequestBody).ToList())
//                    {
//                        if (!string.IsNullOrEmpty(StrParam)) StrParam += "&";
//                        StrParam += $"{item.Name}={item.Value}";
//                    }

//                    request.Parameters.Add(new Parameter("undefined", StrParam, ParameterType.RequestBody));
//                }


//                response = null;
//                switch (connectType)
//                {
//                    case ConnectType.GET:
//                        response = client.Get(request);
//                        break;
//                    case ConnectType.POST:
//                        response = client.Post(request);
//                        break;
//                    case ConnectType.DELETE:
//                        response = client.Delete(request);
//                        break;
//                    case ConnectType.PUT:
//                        response = client.Put(request);
//                        break;
//                    default:
//                        break;
//                }

//                if (Response == null)
//                    throw new AppException("پاسخی مناسب از سرویس دهنده دریافت نشد");

//                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
//                {
//                    try
//                    {
//                        if (jsonConvert.TryDeserializeObject<T>(Response.Content))
//                        {
//                            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Response.Content);
//                        }
//                        throw new AppException(Response.Content);

//                        // return new Core.ViewModel.Response { result = 1, message = Newtonsoft.Json.JsonConvert.DeserializeObject<Core.ViewModel.Response>(ReturnData.Content).message };
//                    }
//                    catch (Exception)
//                    {
//                        throw new AppException(Response.Content);
//                    }

//                }
//                else
//                {
//                    try
//                    {
//                        throw new AppException(Response.Content);

//                    }
//                    catch (Exception)
//                    {
//                        throw new AppException(Response.Content);

//                    }

//                }
//            }
//            catch (Exception e)
//            {

//                throw e;
//            }

//        }
//        //public async Task<T> ConnectingAsync<T>(string Url, ConnectType connectType, object Data)
//        //{
//        //    try
//        //    {
//        //        var Request = new RestRequest(Url);
//        //        if (Params != null && Params.Where(t => t.Type == ParameterType.HttpHeader).Any())
//        //        {
//        //            foreach (var item in Params.Where(t => t.Type == ParameterType.HttpHeader).ToList())
//        //            {
//        //                Request.AddHeader(item.Name, item.Value.ToString());
//        //            }
//        //        }

//        //        if (Data != null)
//        //            Request.AddJsonBody(Data);

//        //        if (Params != null && Params.Where(t => t.Type == ParameterType.RequestBody).Any())
//        //        {
//        //            Request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
//        //            var paramsw = Params.Where(t => t.Type == ParameterType.RequestBody).Select(t => t.Name).ToList();
//        //            string StrParam = null;
//        //            foreach (var item in Params.Where(t => t.Type == ParameterType.RequestBody).ToList())
//        //            {
//        //                if (!string.IsNullOrEmpty(StrParam)) StrParam += "&";
//        //                StrParam += $"{item.Name}={item.Value}";
//        //            }

//        //            Request.Parameters.Add(new Parameter("undefined", StrParam, ParameterType.RequestBody));

//        //        }


//        //        IRestCl Response = null;
//        //        switch (connectType)
//        //        {
//        //            case ConnectType.GET:
//        //                Response =await client.GetAsync<T>(Request);
//        //                break;
//        //            case ConnectType.POST:
//        //                Response =await client.Post(Request);
//        //                break;
//        //            case ConnectType.DELETE:
//        //                Response =await client.Delete(Request);
//        //                break;
//        //            case ConnectType.PUT:
//        //                Response =await client.Put(Request);
//        //                break;
//        //            default:
//        //                break;
//        //        }

//        //        if (Response == null)
//        //            throw new AppException("پاسخی مناسب از سرویس دهنده دریافت نشد");

//        //        if (Response.StatusCode == System.Net.HttpStatusCode.OK)
//        //        {
//        //            try
//        //            {
//        //                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Response.Content); // return new Core.ViewModel.Response { result = 1, message = Newtonsoft.Json.JsonConvert.DeserializeObject<Core.ViewModel.Response>(ReturnData.Content).message };
//        //            }
//        //            catch (Exception)
//        //            {
//        //                throw new AppException(Response.Content);
//        //            }

//        //        }
//        //        else
//        //        {
//        //            try
//        //            {
//        //                throw new AppException(Response.Content);

//        //            }
//        //            catch (Exception)
//        //            {
//        //                throw new AppException(Response.Content);

//        //            }

//        //        }
//        //    }
//        //    catch (Exception e)
//        //    {

//        //        throw new AppException(ApiResultStatusCode.ServerError, e);
//        //    }

//        //}

//    }
//}


