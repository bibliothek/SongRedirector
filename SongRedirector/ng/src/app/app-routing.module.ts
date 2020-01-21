import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmbeddedVideoComponent } from './embedded-video/embedded-video.component';
import { EditComponent } from './edit/edit.component';
import { RedirectComponent } from './redirect/redirect.component';


const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'Home/Embed/default'},
  {path: 'Home/Embed/:config', component: EmbeddedVideoComponent},
  {path: 'Home/Index/:config', component: RedirectComponent},
  {path: 'Config/Index/:config', component: EditComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
