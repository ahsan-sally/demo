using System.Net;
 
public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");
     
    // parse query parameter
    string celsius = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "celsius", true) == 0).Value;
     
    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();
     
    // Set name to query string or body data
    var fahrenheit = (decimal.Parse(celsius) * 9 / 5) + 32;
     
    return celsius == null ? 
    req.CreateResponse(HttpStatusCode.BadRequest, "Please pass in a Celsius value on the query string or in the request body") : 
    req.CreateResponse(HttpStatusCode.OK, $"{celsius} Celsius is {fahrenheit} Fahrenheit");
}