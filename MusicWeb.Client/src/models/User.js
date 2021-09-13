export default class User {
    username = "";
    password = "";

    constructor($data) {
        if ($data) {
            this.username = $data.username;
            this.password = $data.password;
        }
    }
}
