import { JobCreateComponent } from './components/job/job-create/job-create.component';
import { JobCrudComponent } from './views/job-crud/job-crud.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { JobEditComponent } from './components/job/job-edit/job-edit.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'jobs',
    component: JobCrudComponent
  },
  {
    path: 'jobs/new',
    component: JobCreateComponent
  },
  {
    path: 'jobs/edit/:id',
    component: JobEditComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
