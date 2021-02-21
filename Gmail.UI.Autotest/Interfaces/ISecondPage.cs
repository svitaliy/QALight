using Gmail.UI.Autotests.Models;

namespace Gmail.UI.Autotests.Interfaces
{
    public interface ISecondPage : IBasePage
    {
        void FillNewMessage(NewMessageModel messageModel);
        void SendMessage();


        string GetBlockName();
    }
}