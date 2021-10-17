class Request {
    constructor(method, uri, version, message) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }
}

let gg = new Request('POST', 'http://softuni.cbg', 'HTTP/1.3', '')
console.log(gg);