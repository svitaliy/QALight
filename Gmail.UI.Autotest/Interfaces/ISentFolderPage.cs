using Gmail.UI.Autotests.Models;
using System.Collections.Generic;

namespace Gmail.UI.Autotests.Interfaces
{
    public interface ISentFolderPage : IBasePage
    {
        IEnumerable<MainAreaMsgModel> GetSentFolderInfo(int maxCount);
    }
}