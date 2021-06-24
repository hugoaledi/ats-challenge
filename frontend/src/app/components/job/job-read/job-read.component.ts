import { JobService } from './../../../services/job.service';
import { Component, OnInit } from '@angular/core';
import { PoDialogService, PoListViewAction } from '@po-ui/ng-components';
import { Router } from '@angular/router';
import { JobModel } from 'src/app/models/job.model';

@Component({
  selector: 'app-job-read',
  templateUrl: './job-read.component.html',
  styleUrls: ['./job-read.component.css'],
  providers: [JobService]
})
export class JobReadComponent implements OnInit {

  jobList: Array<JobModel> = [];

  readonly actions: Array<PoListViewAction> = [
    {
      label: 'Editar',
      icon: 'po-icon-edit',
      type: 'default',
      action: this.editJob.bind(this)
    },
    {
      label: 'Excluir',
      icon: 'po-icon-delete',
      type: 'danger',
      action: this.deleteJob.bind(this)
    },
  ];

  constructor(private router: Router, private jobService: JobService, private poAlert: PoDialogService) { }

  private loadData(): void {
    this.jobService.readAll().subscribe(resp => {
      this.jobList = resp;
    });
  }

  private editJob(job: JobModel) {
    this.router.navigate([`/jobs/edit/${job.id}`]);
  }

  private deleteJob(job: JobModel) {
    this.poAlert.confirm({
      title: 'Atenção!',
      message: `Deseja remover a vaga "${job.title}"?`,
      confirm: () => {
        this.jobService.delete(job.id).subscribe(_ => this.loadData());
      }
    });
  }

  ngOnInit(): void {
    this.loadData();
  }
}
