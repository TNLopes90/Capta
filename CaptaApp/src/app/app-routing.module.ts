import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JogadoresComponent } from './jogadores/jogadores.component';
import { HabilidadesComponent } from './habilidades/habilidades.component';
import { TimesComponent } from './times/times.component';


const routes: Routes = [
  { path: 'jogadores', component: JogadoresComponent },
  { path: 'habilidades', component: HabilidadesComponent },
  { path: 'times', component: TimesComponent },
  { path: '', component: TimesComponent },
  { path: '**', component: TimesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
