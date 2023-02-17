using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3A.UI.Forms
{
    public enum PortalMenuSelection
    {
        ShowMenu,
        GetLinkedPerson,
        DoSelectLinkedMember,
        DoMemberMaintenance,
        DoEditMemberEnrolment,
        DoViewMemberEnrolment,
        DoShowLeaderMenu,
        DoMemberPayment,
        DoMemberPaymentPreamble,
        DoMemberPaymentDirectDebit,
        DoLinkNewMember,
        DoLinkExistingMember,
        DoUnlinkMember,
        DoWhatsOn,
        NotImplemented
    }

    public enum PortalMenuResult {
        MenuOptionCompleted,
        MenuOptionCancelled,
        MemberDetailsCompleted,
        EnrolmentCancelledTermNotDefined,
    }
}
