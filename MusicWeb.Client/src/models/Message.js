export default class Message {
  type = "";
  content = "";
  src = "";
  preview = "";
  participantId = null;
  timestamp = "";
  uploaded = false;
  viewed = false;
  constructor($data) {
    if ($data) {
      this.type = $data.type;
      this.content = $data.content;
      this.src = $data.src;
      this.preview = $data.preview;
      this.participantId = $data.participantId;
      this.timestamp = $data.timestamp;
      this.uploaded = $data.uploaded;
      this.viewed = $data.viewed;
    }
  }
}
