import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavComponent } from './nav/nav.component';
import { EmbeddedVideoComponent } from './embedded-video/embedded-video.component';
import { EditComponent } from './edit/edit.component';


const routes: Routes = [
  {path: '', pathMatch: 'full', component: EmbeddedVideoComponent},
  {path: 'edit', component: EditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
