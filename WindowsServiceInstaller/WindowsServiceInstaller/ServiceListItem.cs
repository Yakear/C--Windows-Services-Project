using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceInstaller
{
    public class ServiceListItem
    {
        public ServiceListItem(ManagementBaseObject o)
        {
            this.Name = o["name"].ToString();
            this.DisplayName = o["displayname"].ToString();
            this.Description = o["description"]?.ToString();
            this.Status = o["status"]?.ToString();
            this.StartType = o["startmode"]?.ToString();
            this.StartName = o["startname"]?.ToString();
            this.State = o["state"]?.ToString();
            this.AcceptPause = o["acceptpause"]?.ToString();
            this.Caption = o["caption"]?.ToString();
            this.ServiceType = o["servicetype"]?.ToString();
            this.ProcessId = o["processid"]?.ToString();
            this.PathName = o["pathname"]?.ToString();
            this.DelayedAutoStart = o["delayedautostart"]?.ToString();
            this.DesktopInteract = o["desktopinteract"]?.ToString();
            this.ErrorControl = o["errorcontrol"]?.ToString();
            this.ExitCode = o["exitcode"]?.ToString();
            this.InstallDate = o["installdate"]?.ToString();
            this.WaitHint = o["waithint"]?.ToString();
            this.SystemName = o["systemname"]?.ToString();
            this.ServiceSpecificExitCode = o["servicespecificexitcode"]?.ToString();
        }

        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? ProcessId { get; set; }
        public string? StartType { get; set; }
        public string? State { get; set; }
        public string? ServiceType { get; set; }
        public string? StartName { get; set; }
        public string? AcceptPause { get; set; }
        public string? Status { get; set; }
        public string? Caption { get; set; }
        public string? PathName { get; set; }
        public string? DelayedAutoStart { get; set; }
        public string? DesktopInteract { get; set; }
        public string? ErrorControl { get; set; }
        public string? ExitCode { get; set; }
        public string? InstallDate { get; set; }
        public string? WaitHint { get; set; }
        public string? SystemName { get; set; }
        public string? ServiceSpecificExitCode { get; set; }

    }
}
