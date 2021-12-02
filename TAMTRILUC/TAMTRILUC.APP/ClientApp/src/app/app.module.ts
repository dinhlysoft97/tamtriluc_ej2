import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { GridModule } from '@syncfusion/ej2-angular-grids';
import { DatePickerAllModule } from '@syncfusion/ej2-angular-calendars'
import { PageService, SortService, FilterService, GroupService, EditService, ToolbarService } from '@syncfusion/ej2-angular-grids';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UserComponent } from './user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    UserComponent
  ], 
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    GridModule,
    DatePickerAllModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'user-data', component: UserComponent },
    ])
  ],
  providers: [PageService,
    SortService,
    FilterService,
    GroupService,
    EditService,
    ToolbarService],
  bootstrap: [AppComponent]
})
export class AppModule { }
