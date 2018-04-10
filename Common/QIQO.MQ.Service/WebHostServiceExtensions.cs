using Microsoft.AspNetCore.Hosting;
using QIQO.MQ.Service;
using System.ServiceProcess;

public static class WebHostServiceExtensions
{
    public static void RunAsCustomService(this IWebHost host)
    {
        var webHostService = new QIQOWebHostService(host);
        ServiceBase.Run(webHostService);
    }
}