<template>
  <div class="container-md">
    <ul class="nav">
      <li class="nav-item">
        <a class="nav-link" href="#" v-on:click="searchOrHistory()">Search</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#" v-on:click="searchOrHistory()">History</a>
      </li>
    </ul>
   
    <div v-if="!showHistory" class="weatherSearch">
      <WeatherSearch />
    </div>
    <div v-if="showHistory" class="weatherHistory">
      <WeatherHistory />
    </div>
  </div>

</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Action, Getter } from "vuex-class";
import WeatherSearch from "./Components/WeatherSearch.vue";
import WeatherHistory from "./Components/WeatherHistory.vue";

@Component({
  components: {
    WeatherSearch,
    WeatherHistory
  }
})
export default class App extends Vue {
  showHistory = false;

  mounted() {
    this.getHistory();
  }

  @Action
  private fetchHistory!: () => Promise<void>;

  private async getHistory(): Promise<void> {
    await this.fetchHistory();
  }

  searchOrHistory() {
    this.showHistory = !this.showHistory;
  }
}
</script>

<style scoped>


.nav{
  padding-top: 10px;
  padding-bottom: 10px;
}

</style>
