using System;
using System.Collections.Specialized;
using System.Net;

namespace ZahidAGA
{
	// Token: 0x0200000B RID: 11
	public class LogUtils
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x00002BF7 File Offset: 0x00000DF7
		public void send(string content, string webHookUrl)
		{
			LogUtils.Http.Post(webHookUrl, new NameValueCollection
			{
				{
					"content",
					content
				}
			});
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00002C11 File Offset: 0x00000E11
		public void send(string content, string webHookUrl, string username)
		{
			LogUtils.Http.Post(webHookUrl, new NameValueCollection
			{
				{
					"content",
					content
				},
				{
					"username",
					username
				}
			});
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00002C37 File Offset: 0x00000E37
		public void send(string content, string webHookUrl, string username, string avatarUrl)
		{
			LogUtils.Http.Post(webHookUrl, new NameValueCollection
			{
				{
					"content",
					content
				},
				{
					"username",
					username
				},
				{
					"avatarURL",
					avatarUrl
				}
			});
		}

		// Token: 0x0200000C RID: 12
		private class Http
		{
			// Token: 0x060000CC RID: 204 RVA: 0x000071EC File Offset: 0x000053EC
			public static byte[] Post(string url, NameValueCollection pairs)
			{
				byte[] result;
				using (WebClient webClient = new WebClient())
				{
					result = webClient.UploadValues(url, pairs);
				}
				return result;
			}
		}
	}
}
