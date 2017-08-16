using BackToBg.Core.Business.UtilityInterfaces;

namespace BackToBg.Core.Business.Common
{
    public class CustomEventHandler : ICustomEventHandler
    {
        private readonly IWriter writer;

        public CustomEventHandler(IWriter writer)
        {
            this.writer = writer;
        }

        public void QuestCompletion(object sender, QuestCompletionEventArgs args)
        {
            this.writer.DisplayQuestCompletionMessage($"{args.Name} has been completed!");
        }
    }
}