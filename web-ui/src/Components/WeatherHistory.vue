<template>
  <div class="history">
    <div class="row">
      <div class=".col-12 header">
        <div class="alert alert-info" role="alert">
          <h2>Weather History</h2>
        </div>
        <div class="list-group">
          <span v-for="(forecast,i) in FORECAST_HISTORY" v-bind:key="i">
            <button
              type="button"
              v-on:click="changeSelected(forecast)"
              class="list-group-item list-group-item-action"
            >{{forecast.searchKey}}</button>
          </span>
        </div>
      </div>

      <div v-if="selectedForecast && selectedForecast.responses" class=".col-12 forecast">
        <div class="alert alert-success" role="alert">
          <h4>{{selectedForecast.searchKey}}</h4>
        </div>
        
        <Weather :weatherInfo="selectedForecast" />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Watch } from "vue-property-decorator";
import Forecast from "../models/Forecast";
import Weather from "./Weather.vue";
import { Action, Getter } from "vuex-class";

@Component({
  components: {
    Weather
  }
})
export default class WeatherSearch extends Vue {
  @Getter
  private FORECAST_HISTORY!: Array<Forecast>;

  @Action
  private fetchHistory!: () => Promise<void>;

  public selectedForecast = new Forecast();

  mounted() {
    console.log("Weather history: Mounted");
    this.getHistory();
  }

  changeSelected(newForecast: Forecast) {
    this.selectedForecast = newForecast;
  }

  private async getHistory(): Promise<void> {
    await this.fetchHistory();
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.history {
  padding-left: 15px;
  padding-right: 15px;
}

.forecast{
  padding: 5px;
}
</style>
