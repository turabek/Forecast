<template>
  <div class="weatherSearch">
    <div class="alert alert-info" role="alert">
      <h2>Weather forecast</h2>
    </div>

    <div class="input-group mb-3">
      <input type="text" class="form-control" placeholder="City name or Zip code..." v-model="searchKey" aria-label="City name or Zip code..." aria-describedby="button-addon2">
      <div class="input-group-append">
        <button class="btn btn-outline-success" type="button" id="button-addon2" v-on:click="getForecast()">Search</button>
      </div>
    </div>


    <div v-if="FORECAST && FORECAST.isSuccesful==false" class="alert alert-warning">
      <h4>{{FORECAST.description}}</h4>
    </div>

    <div v-else-if="FORECAST && FORECAST.responses" >
      <div class="alert alert-success" role="alert">
        <h2>{{FORECAST.searchKey}}</h2>
      </div>
      
      <Weather :weatherInfo="FORECAST" />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Forecast from "../models/Forecast";
import Weather from "./Weather.vue";
import { Action, Getter } from "vuex-class";

@Component({
  components: {
    Weather
  }
})
export default class WeatherSearch extends Vue {
  public searchKey = "";

  @Getter
  private FORECAST!: Forecast;

  @Action
  private fetchForecast!: (cityOrZipCode: string) => Promise<void>;

  
  private async getForecast(): Promise<void> {
    await this.fetchForecast(this.searchKey);
  }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.weatherSearch{
    margin:5px;
  }
</style>
