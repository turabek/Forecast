export default class WeatherResponse {
    date: Date;
    temperature: number;
    humidity: number;
    windSpeed: number;

    constructor() {
        this.date = new Date();
        this.temperature = 0;
        this.humidity = 0;
        this.windSpeed = 0;
    }
}