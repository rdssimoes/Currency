using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Exchange.Application
{
    public class RateService : IRateService
    {
        #region [ private ]

        private const string url = "http://api.exchangeratesapi.io/v1/latest?access_key=fb8cd46bac80d5ac44cfd6734643aac3";
        private static HttpClient _httpClient;
        private static HttpClient HttpClient => _httpClient ?? (_httpClient = new HttpClient());

        #endregion

        #region [ Methods ]

        public async Task<Rate> Convert(Rate rat, ISegmentService segmentService)
        {
            #region [ variable ]

            decimal brl = 0;
            decimal cur = 0;
            decimal conv = 0;
            decimal value = 0;

            #endregion

            try
            {
                decimal segmentRate = await segmentService.GetSegmentRate(rat.Segment.Value);

                HttpResponseMessage response = await HttpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string apiReturn = await response.Content.ReadAsStringAsync();
                    JObject fields = JObject.Parse(apiReturn);

                    string strBrl = fields["rates"]["BRL"].ToString();
                    string strCur = fields["rates"][rat.Currency].ToString();

                    if (decimal.TryParse(strBrl, out brl))
                    {
                        if (decimal.TryParse(strCur, out cur))
                        {
                            conv = brl / cur;
                            value = (rat.Qty.Value * conv) * (1 + (segmentRate / 100));
                        }
                    }
                }
            }
            catch (Exception ex) { }

            rat.Value = string.Format("{0:C}", value);
            return rat;
        }

        #endregion
    }
}
