using System;
using Nancy;
using Nancy.Responses;

namespace __NAME__.Host.Modules
{
    public class PingModule : NancyModule
    {
        private readonly string _output = string.Format(@"__NAME__.Api
Status=active
date={0}", DateTime.Now);

        public PingModule()
        {
            Get["ping"] = _ => new TextResponse(_output);
        }
    }
}