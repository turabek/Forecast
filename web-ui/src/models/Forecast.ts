import WeatherResponse from './WeatherResponse';
export default class Forecast {
    searchKey!:string
    isSuccesful!: boolean
    responses!: Array<WeatherResponse>
    description!: string
}