import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavComponent } from './nav/nav.component';
import { EmbeddedVideoComponent } from './embedded-video/embedded-video.component';


const routes: Routes = [
  {path: '', pathMatch: 'full', component: EmbeddedVideoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
