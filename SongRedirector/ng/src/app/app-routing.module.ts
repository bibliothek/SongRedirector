import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmbeddedVideoComponent } from './embedded-video/embedded-video.component';
import { EditComponent } from './edit/edit.component';


const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'Home/Embed/default'},
  {path: 'Home/Embed/:id', component: EmbeddedVideoComponent},
  {path: 'Config/Index/:id', component: EditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
