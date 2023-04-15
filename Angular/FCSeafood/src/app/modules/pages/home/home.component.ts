import {Component, NgModule} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

}


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  }
];

@NgModule({
  declarations: [HomeComponent],
  imports: [RouterModule.forChild(routes), NgIf],
  exports: [RouterModule]
})
export class HomeModule {
}
