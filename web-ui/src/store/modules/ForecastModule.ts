import { VuexModule, Module, Mutation, Action } from 'vuex-module-decorators'
import Forecast from '@/models/Forecast'
import { Inject } from 'inversify-props'
import IForecastService from '@/services/IForecastService'

@Module
export default class ForecastModule extends VuexModule {

    @Inject()
    private forecastService!: IForecastService

    public forecast= new Forecast()
   
    @Action({ rawError: true })
    public async fetchForecast(cityOrZipCode: string): Promise<void> {
        const newForecast = await this.forecastService.GetForecast(cityOrZipCode)
        this.context.commit('setForecast', newForecast)
    }

    @Mutation
    setForecast(newForecast: Forecast) {
        this.forecast = newForecast
    }



    get FORECAST(): Forecast {
        return this.forecast
    }
}

