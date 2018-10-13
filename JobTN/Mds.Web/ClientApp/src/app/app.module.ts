import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CatalogComponent } from './catalog/catalog.component';
import { CreateCatalogComponent } from './create-catalog/create-catalog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule } from '@progress/kendo-angular-grid';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CatalogComponent,
    CreateCatalogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    ButtonsModule,
    GridModule,
    DropDownsModule,
    BrowserAnimationsModule,
    HttpClient,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: CatalogComponent, pathMatch: 'full' },
      { path: 'create', component: CatalogComponent },
      { path: 'create-catalog', component: CreateCatalogComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
