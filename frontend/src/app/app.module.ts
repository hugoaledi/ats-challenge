import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PoModule } from '@po-ui/ng-components';
import { RouterModule } from '@angular/router';
import { JobReadComponent } from './components/job/job-read/job-read.component';
import { HomeComponent } from './views/home/home.component';
import { JobCrudComponent } from './views/job-crud/job-crud.component';
import { JobCreateComponent } from './components/job/job-create/job-create.component';
import { JobFormComponent } from './components/job/job-form/job-form.component';
import { JobEditComponent } from './components/job/job-edit/job-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    JobReadComponent,
    JobCrudComponent,
    JobCreateComponent,
    JobFormComponent,
    JobEditComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    PoModule,
    RouterModule.forRoot([])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
