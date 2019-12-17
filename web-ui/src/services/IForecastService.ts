import Forecast from '@/models/Forecast';

export default interface IForecastService{
    GetForecast(cityOrZipCode:string):Promise<Forecast>
}