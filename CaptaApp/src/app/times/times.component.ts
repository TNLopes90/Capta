import { Time } from '../_models/Time';
import { ToastrService } from 'ngx-toastr';
import { BsModalService } from 'ngx-bootstrap';
import { Component, OnInit } from '@angular/core';
import { TimeService } from '../_services/time.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-times',
  templateUrl: './times.component.html',
  styleUrls: ['./times.component.css']
})
export class TimesComponent implements OnInit {

  _filtroTime = '';
  times: Time[] = [];
  time: Time;
  timesFiltrados: Time[] = [];
  registerForm: FormGroup;
  postORPut: string;
  bodyDeletarTime: string;

  constructor(
    private timeServices: TimeService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private toastr: ToastrService) { }

  get filtroTime(): string {
    return this._filtroTime;
  }

  set filtroTime(value) {
    this._filtroTime = value;
    this.timesFiltrados = this._filtroTime ? this.filtrarTime(this._filtroTime) : this.times;
  }

  ngOnInit() {
    this.validation();
    this.getAllTimes();
  }

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  getAllTimes() {
    this.timeServices.getAllTimes().subscribe(
      (_times: Time[]) => {
        this.times = _times;
        this.timesFiltrados = this.times;
      }, error => console.log(error)
    );
  }

  filtrarTime(filtro: string): Time[] {
    filtro = filtro.toLocaleLowerCase();
    return this.times.filter(t => t.nome.toLocaleLowerCase().indexOf(filtro) !== -1);
  }

  validation() {
    this.registerForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      forca: ['', [Validators.required, Validators.min(1), Validators.max(100)]]
    });
  }

  salvarTime(template: any) {
    if (this.registerForm.valid) {
      if(this.postORPut === 'post') {
        this.time = Object.assign({}, this.registerForm.value);
        this.timeServices.postTime(this.time).subscribe(
          () => {
            this.getAllTimes();
            template.hide();
            this.toastr.success('Time salvo com sucesso!');
          }, error => {
            this.toastr.error(`Falhar ao salvar o time ${error}`);
          }
        );
      } else {
        this.time = Object.assign({ timeId: this.time.timeId }, this.registerForm.value);
        this.timeServices.putTime(this.time).subscribe(
          () => {
            template.hide();
            this.getAllTimes();
            this.toastr.success('Time alterado com sucesso!');
          }, error => {
            this.toastr.error(`Falhar ao salvar o time ${error}`);
          }
        );
      }
    }
  }

  editarTime(timeEdit: Time, template: any) {
    this.postORPut = 'put';
    this.openModal(template);
    this.time = timeEdit;
    this.registerForm.patchValue(timeEdit);
  }

  excluirTime(timeExcluir: Time, template: any) {
    this.time = timeExcluir;
    this.openModal(template);
    this.bodyDeletarTime = `Tem certeza que deseja excluir o Time: ${timeExcluir.nome}, Código: ${timeExcluir.timeId}?`;
  }

  confirmeDelete(template: any) {
    this.timeServices.deleteTime(this.time.timeId).subscribe(
      () => {
        template.hide();
        this.getAllTimes();
        this.toastr.success('Time excluido com sucesso!');
      }, error => {
        this.toastr.error(`Falha ao excluir o time! ${error}`);
      }
    );
  }

  novoTime(template: any) {
    this.postORPut = 'post';
    this.openModal(template);
  }

}
