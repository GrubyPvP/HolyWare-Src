using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZahidAGA
{
	// Token: 0x02000004 RID: 4
	public class DWC
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000020B5 File Offset: 0x000002B5
		public DWC(string webhookURL)
		{
			this.WebhookURL = new Uri(webhookURL);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000049D4 File Offset: 0x00002BD4
		public void PostMessage(message)
		{
			HttpWebRequest httpWebRequest = WebRequest.CreateHttp(this.WebhookURL);
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/json";
			string s = JsonConvert.SerializeObject(message);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			httpWebRequest.ContentLength = (long)bytes.Length;
			using (Stream requestStream = httpWebRequest.GetRequestStream())
			{
				requestStream.Write(bytes, 0, bytes.Length);
				requestStream.Flush();
			}
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00004A60 File Offset: 0x00002C60
		public Task PostMessageAsync(message)
		{
			DWC.<PostMessageAsync>d__3 <PostMessageAsync>d__;
			<PostMessageAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<PostMessageAsync>d__.<>4__this = this;
			<PostMessageAsync>d__.message = message;
			<PostMessageAsync>d__.<>1__state = -1;
			<PostMessageAsync>d__.<>t__builder.Start<DWC.<PostMessageAsync>d__3>(ref <PostMessageAsync>d__);
			return <PostMessageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04000005 RID: 5
		public Uri WebhookURL;
	}
}
