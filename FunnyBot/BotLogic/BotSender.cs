using Telegram.Bot.Types;

namespace FunnyBot
{
    class BotSender : Bot
    {
        public static void SendMessage(long chatId, string text)
        {
            BotClient.SendTextMessageAsync(chatId, text);
        }

        public static void SendPicture(long chatId, FileToSend file)
        {
            BotClient.SendPhotoAsync(chatId, file);
        }
    }
}
