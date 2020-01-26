import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmbeddedVideoComponent } from './embedded-video/embedded-video.component';
import { LinkListComponent } from './edit/link-list/link-list.component';
import { RedirectComponent } from './redirect/redirect.component';
import { LinkEditComponent } from './edit/link-edit/link-edit.component';
import { NewLinkComponent } from './edit/new-link/new-link.component';


const routes: Routes = [
  {path: ':config', component: EmbeddedVideoComponent},
  {path: 'Home/Embed/:config', redirectTo: ':config'},
  {path: ':config/redirect', component: RedirectComponent},
  {path: 'Home/Index/:config', redirectTo: ':config/redirect'},
  {path: ':config/edit/new', component: NewLinkComponent},
  {path: ':config/edit/:id', component: LinkEditComponent},
  {path: ':config/edit', component: LinkListComponent},
  {path: 'Config/Index/:config', redirectTo: ':config/edit'},
  {path: '**', redirectTo: 'default'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
