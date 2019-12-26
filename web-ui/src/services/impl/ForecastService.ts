import axios from 'axios'
import Forecast from '@/models/Forecast';
import IForecastService from '@/services/IForecastService';
import { injectable, Inject } from 'inversify-props';
import IOfflineService from '../IOfflineService';

@injectable()
export default class ForecastService implements IForecastService  {
    
    @Inject()
    private offlineService!: IOfflineService

    private readonly API_URL: string = process.env.VUE_APP_API_URL;

    public async GetForecast(cityOrZipCode:string):Promise<Forecast>{
        let result:Forecast;
        if (this.isZipCodeWithCountryCode(cityOrZipCode)) {
            result = await  this.GetForecastByZipCode(cityOrZipCode)
        } else {
            result = await this.GetForecastByCity(cityOrZipCode)
        }

        // Save to Local storage if succesful reply
        if(result.isSuccesful){
            this.insertToHistoryList(result);
        }

        return result;

        
    }

    private isZipCodeWithCountryCode(value:string):boolean{
        const zipCodePattern = /^\d{5},\s{2}$/;
        return zipCodePattern.test(value);
    }

    private async GetForecastByCity(city: string): Promise<Forecast> {
        const URL = `${this.API_URL}/ByCity/${city}`
        const httpResponse = await axios.get<Forecast>(URL)
        return httpResponse.data
    }
    
    private async GetForecastByZipCode(zipCode: string): Promise<Forecast> {
        const URL = `${this.API_URL}/ByZipCode/${zipCode}`
        const httpResponse = await axios.get<Forecast>(URL)
        return httpResponse.data
    }



    
  
  private async insertToHistoryList(newForecast:Forecast): Promise<void> {
    this.offlineService.insertNew(newForecast);
  }


}