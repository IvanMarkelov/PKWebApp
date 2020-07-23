class Client {
    constructor(private firstName: string, private lastName: string) {
    }

    public showName() {
        alert(this.firstName + " " + this.lastName);
    }

    public visits: number = 0;
    private ourName: string

    get name() {
        return this.ourName;
    }

    set name(val) {
        this.ourName = val;
    }
}