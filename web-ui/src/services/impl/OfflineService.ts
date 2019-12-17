import axios from 'axios'
import Forecast from '@/models/Forecast';
import IOfflineService from '@/services/IOfflineService';
import { injectable } from 'inversify-props';

@injectable()
export default class OfflineService implements IOfflineService {
    
    storageName='forecastHistory';
    insertNew(newForecast: Forecast) {
        let result = Array<Forecast>();
        const serializedForecastHistory=localStorage.getItem(this.storageName);
        if (serializedForecastHistory) {
            result = JSON.parse(serializedForecastHistory as string);
        }
        result.push(newForecast);
        localStorage.setItem(this.storageName,JSON.stringify(result));
    }

    public async GetAll(): Promise<Array<Forecast>> {
        let result = Array<Forecast>();
        const serializedForecastHistory=localStorage.getItem(this.storageName);
        if (serializedForecastHistory) {
            result = JSON.parse(serializedForecastHistory as string);
        }
        return result;
    }

}