﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebApi_UploadAndDownloadFiles.Repository
{
    public class DownloadRepository
    {
        public HttpResponseMessage DirectDownloadFromBase64(int FileId)
        {
            using (FileEntities db = new FileEntities())
            {
                var fileData = db.FileDatas.Where(x => x.Id == FileId).FirstOrDefault();

                string fileName = fileData.FileName;// + ".pdf";//"Document" + DateTime.Now.ToString("_MMMdd_yyyy_HHmmss") + ".pdf";
                string base64formatstring = fileData.File; //"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Eiur+61godFwQffKUkrJ0Ds2gutRADY0GmjHCOiXODpX4iAlX0CTSICwakG6Jq7IEs74au/nQjPqYD+it/f1CQ4beEF8JuiZrmuHZ8LvUfaVG2HGVOIhd8zp+Ee3cHE3owt843g6rS00mA57UQvlvDNaTY8VoZx4HBdeM/DhBJ0yIo04Dx+HFFS/naLv4ZZbDH3H+9g7nOHQAbzI0Y6sEbayz9hv4M12lRTI/XIShl8decob9j7q9TGYJXntz+Pru6Q46ezsQeJsnL3GOgY/vh1eAr6VoC0xXnDcZ2vlfy/Dm/2wmMD1/gCKDxwTmyRwt/xx+A/4JtqcbHKHyDLcertazbJUAjgz4MitO8HsUMb4qxYDvH0Ue1y8g/wHHBQ2GCmVuZHN0cmVhbQplbmRvYmoKOCAwIG9iago8PC9UeXBlL1BhZ2UvTWVkaWFCb3hbMCAwIDU5NSA4NDJdL1Jlc291cmNlczw8L0ZvbnQ8PC9GMiAzIDAgUi9GMSAyIDAgUj4+Pj4vQ29udGVudHMgNyAwIFIvUGFyZW50IDUgMCBSPj4KZW5kb2JqCjIgMCBvYmoKPDwvVHlwZS9Gb250L1N1YnR5cGUvVHlwZTEvQmFzZUZvbnQvSGVsdmV0aWNhL0VuY29kaW5nL1dpbkFuc2lFbmNvZGluZz4+CmVuZG9iagozIDAgb2JqCjw8L1R5cGUvRm9udC9TdWJ0eXBlL1R5cGUxL0Jhc2VGb250L0hlbHZldGljYS1Cb2xkL0VuY29kaW5nL1dpbkFuc2lFbmNvZGluZz4+CmVuZG9iago1IDAgb2JqCjw8L1R5cGUvUGFnZXMvQ291bnQgMi9LaWRzWzYgMCBSIDggMCBSXT4+CmVuZG9iago5IDAgb2JqCjw8L1R5cGUvQ2F0YWxvZy9QYWdlcyA1IDAgUj4+CmVuZG9iagoxMCAwIG9iago8PC9Qcm9kdWNlcihpVGV4dFNoYXJwkiA1LjUuMTEgqTIwMDAtMjAxNyBpVGV4dCBHcm91cCBOViBcKEFHUEwtdmVyc2lvblwpKS9DcmVhdGlvbkRhdGUoRDoyMDE3MDkxOTEzMDI1OCswNSczMCcpL01vZERhdGUoRDoyMDE3MDkxOTEzMDI1OCswNSczMCcpPj4KZW5kb2JqCnhyZWYKMCAxMQowMDAwMDAwMDAwIDY1NTM1IGYgCjAwMDAwMDAwMTUgMDAwMDAgbiAKMDAwMDAwNTA3MSAwMDAwMCBuIAowMDAwMDA1MTU5IDAwMDAwIG4gCjAwMDAwMDI1ODMgMDAwMDAgbiAKMDAwMDAwNTI1MiAwMDAwMCBuIAowMDAwMDAzNTM5IDAwMDAwIG4gCjAwMDAwMDM2ODMgMDAwMDAgbiAKMDAwMDAwNDk1MCAwMDAwMCBuIAowMDAwMDA1MzA5IDAwMDAwIG4gCjAwMDAwMDUzNTQgMDAwMDAgbiAKdHJhaWxlcgo8PC9TaXplIDExL1Jvb3QgOSAwIFIvSW5mbyAxMCAwIFIvSUQgWzxlOTBiNGFkM2NlM2M0NDkyMTQxZDI2ZGQ3N2IyNzNiNz48ZTkwYjRhZDNjZTNjNDQ5MjE0MWQyNmRkNzdiMjczYjc+XT4+CiVpVGV4dC01LjUuMTEKc3RhcnR4cmVmCjU1MTgKJSVFT0YK";
                if (!string.IsNullOrEmpty(base64formatstring))
                {
                    byte[] bytes = Convert.FromBase64String(base64formatstring);

                    HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
                    httpResponseMessage.Content = new ByteArrayContent(bytes.ToArray());
                    httpResponseMessage.Content.Headers.Add("x-filename", fileName);
                    httpResponseMessage.Content.Headers.Add("Access-Control-Expose-Headers", "x-filename"); //Basically Adding Access-Control-Expose-Headers helps to expose the custom headers to client side.
                    // httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(fileData.FileType);
                    httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    httpResponseMessage.Content.Headers.ContentDisposition.FileName = fileName;
                    httpResponseMessage.StatusCode = HttpStatusCode.OK;
                    return httpResponseMessage;
                }
            }
            return null;
        }

       
    }
}