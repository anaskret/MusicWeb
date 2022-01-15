export default class Message {
  chat_id = null;
  send_date = "";
  participant_id = null;
  participant_name = "";
  text = "";
  image_bytes = "";
  image_path = "";
  is_read = false;
  constructor($data) {
    if ($data) {
      this.chat_id = $data.chatId;
      this.send_date = $data.sendDate;
      this.participant_id = $data.senderId;
      this.participant_name = $data.senderName;
      this.text = $data.text;
      this.image_bytes = $data.imageBytes;
      this.image_path = $data.imagePath;
      this.is_read = $data.isRead;
    }
  }
}
