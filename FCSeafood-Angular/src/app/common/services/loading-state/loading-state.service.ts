import { Injectable } from "@angular/core";
import { LoadingState } from "@common-states/loading.state";

@Injectable({providedIn: 'root'})
export class LoadingStateService {
  loadingItems: number = 0;

  constructor(private loadingState: LoadingState) {
  }

  get state(): LoadingState {
    return this.loadingState;
  }

  show() {
    setTimeout(() => {
      this.loadingItems++;
      if (!this.loadingState.show) {
        this.loadingState.show = true;
      }
    });
  }

  hide() {
    setTimeout(() => {
      if (this.loadingItems > 0) {
        this.loadingItems--;
      }

      if (this.loadingItems == 0) {
        this.loadingState.show = false;
      }
    });
  }
}
