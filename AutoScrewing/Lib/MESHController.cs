using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using AutoScrewing.Models;
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
        private string WORK_ID = string.Empty;
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
            client.Timeout = TimeSpan.FromSeconds(10);
            return client;
        }
        public async Task Tracking(string operationusersn,string workid,string lotno,string matlotno)
        {
            using (var client = GetClient("Tracking"))
            {
                try
                {
                    var payload = new MESHPayload1Model(OPERATION_ID,workid, operationusersn, lotno, matlotno);

                    var res = await client.PostAsJsonAsync("openapi/mes/tracking", payload);
                }
                catch { }
            }
        }
        public async Task Checking(string operationusersn,string workid, string lotno, string matlotno,string result)
        {
            using (var client = GetClient("Tracking"))
            {
                try
                {
                    var payload = new MESHPayload1Model(OPERATION_ID,workid, operationusersn, lotno, matlotno);
                    await client.PostAsJsonAsync("openapi/mes/tracking/check", payload);
                }
                catch { }
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
                log.payload = $"{request.Method} - {(request.Content is not null ? await request.Content.ReadAsStringAsync() : string.Empty)}";
                LogRepository logrepo = new LogRepository();
                HttpResponseMessage res = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                for (int i = 0; i < 3;i++)
                {
                    try
                    {
                        res = await base.SendAsync(request, cancellationToken);
                        res.EnsureSuccessStatusCode();
                        log.status += "-Success";
                        log.result = await res.Content.ReadAsStringAsync();
                        break;
                    }
                    catch (HttpRequestException ex)
                    {
                        log.status += $"-Failed - {ex.StatusCode}";
                        log.result = $"{ex.Message} {ex.HttpRequestError}";
                        res = new HttpResponseMessage(ex.StatusCode ?? System.Net.HttpStatusCode.InternalServerError);
                    }
                    catch (Exception ex)
                    {
                        log.status += "-Failed";
                        log.result = $"{ex.Message} {ex.StackTrace}";
                    }
                }
                await logrepo.RecordLog(log);
                return res;
            }
        }

    }
}
