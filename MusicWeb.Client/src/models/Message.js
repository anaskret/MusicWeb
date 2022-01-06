export default class Message {
  chat_id = null;
  send_date = "";
  participant_id = null;
  participant_name = "";
  content = "";
  type = "";
  src = "";
  preview = "";
  uploaded = false;
  constructor($data) {
    if ($data) {
      this.chat_id = $data.chatId;
      this.send_date = $data.sendDate;
      this.participant_id = $data.senderId;
      this.participant_name = $data.senderName;
      this.content = $data.text;
      this.type = $data.type ? $data.type : "text";
      this.src = $data.src;
      this.preview = $data.preview;
      this.uploaded = $data.uploaded;
    }
  }
}
