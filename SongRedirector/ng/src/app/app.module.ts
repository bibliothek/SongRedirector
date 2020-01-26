import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatSelectModule, MatBadgeModule, MatMenuModule, MatTableModule, MatFormFieldModule, MatInputModule} from '@angular/material';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule, MatIcon } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { NavComponent } from './nav/nav.component';
import { EmbeddedVideoComponent } from './embedded-video/embedded-video.component';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { reducers, metaReducers } from './reducers';
import { EffectsModule } from '@ngrx/effects';
import { LinkEffects } from './link.effects';
import { LinkListComponent } from './edit/link-list/link-list.component';
import { StoreRouterConnectingModule } from '@ngrx/router-store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { RedirectComponent } from './redirect/redirect.component';
import { LinkEditComponent } from './edit/link-edit/link-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LinkFormComponent } from './edit/link-form/link-form.component';
import { NewLinkComponent } from './edit/new-link/new-link.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    EmbeddedVideoComponent,
    LinkListComponent,
    RedirectComponent,
    LinkEditComponent,
    LinkFormComponent,
    NewLinkComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatSelectModule,
    MatListModule,
    MatMenuModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatBadgeModule,
    MatTableModule,
    LayoutModule,
    HttpClientModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    StoreModule.forRoot(reducers, {
      metaReducers,
      runtimeChecks: {
        strictStateImmutability: true,
        strictActionImmutability: true
      },
    }),
    EffectsModule.forRoot([LinkEffects]),
    StoreRouterConnectingModule.forRoot(),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: environment.production })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
