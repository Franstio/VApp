using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace AutoScrewing.Lib
{
    public class MESHController
    {
        private string BASE_ADDRESS = string.Empty;
        private string OPERATION_USER = string.Empty;
        private string OPERATION_ID = string.Empty;
        public MESHController()
        {
            BASE_ADDRESS = Settings1.Default.MESH_URL;
            OPERATION_ID = Settings1.Default.OPERATION_ID;
            OPERATION_USER = Settings1.Default.OPERATION_USER;
        }

        private HttpClient GetClient(string source)
        {
            HttpClient client = new HttpClient(new MESH_HTTP_HANDLER());
            client.BaseAddress = new Uri(BASE_ADDRESS);
            client.DefaultRequestHeaders.TryAddWithoutValidation("X-SOURCE", source);
            return client;
        }
        public async Task Tracking(string Scan_ID)
        {
            using (var client = GetClient("Tracking"))
            {
                var payload =new 
                {
                    operationId=OPERATION_ID,
                    lotNo=Scan_ID,
                    operationUserSN=OPERATION_USER
                };

                await client.PostAsJsonAsync("openapi/mes/tracking/check",payload);
            }
        }

        public class MESH_HTTP_HANDLER : HttpClientHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                string? source = null;
                bool isExist = request.Headers.TryGetValues("X-SOURCE", out var list);
                if (!isExist || list is null)
                    source = "UNKNOWN";
                else
                {
                    source = list.FirstOrDefault() ?? "UNKNOWN";
                    request.Headers.Remove("X-SOURCE");
                }
                LogModel log = new LogModel("HTTP", source, source, "SEND");
                log.Payload = $"{request.Method} - {(request.Content is not null ? await request.Content.ReadAsStringAsync() : string.Empty)}";
                LogRepository logrepo = new LogRepository();
                HttpResponseMessage res;
                try
                {
                    res = await base.SendAsync(request, cancellationToken);
                    res.EnsureSuccessStatusCode();
                    log.Status += "-Success";
                    log.Result = await res.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException ex)
                {
                    log.Status += $"-Failed - {ex.StatusCode}";
                    log.Result = $"{ex.Message} {ex.HttpRequestError}";
                    res = new HttpResponseMessage(ex.StatusCode ?? System.Net.HttpStatusCode.InternalServerError);
                }
                catch (Exception ex)
                {
                    log.Status += "-Failed";
                    log.Result = $"{ex.Message} {ex.StackTrace}";

                    res = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                }
                await logrepo.RecordLog(log);
                return res;
            }
        }

    }
}
