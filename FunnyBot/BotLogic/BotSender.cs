using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace FunnyBot
{
    class BotSender : Bot
    {
        public static void SendMessage(long chatId, string text)
        {
            BotClient.SendTextMessageAsync(chatId, text);
        }

        public static void SendPicture(long chatId, InputOnlineFile file)
        {
            BotClient.SendPhotoAsync(chatId, file);
        }
    }
}
