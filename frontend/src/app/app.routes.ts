import { Routes } from '@angular/router';
import { HeroListComponent } from './pages/hero-list/hero-list.component'
import { HeroFormComponent } from './pages/hero-form/hero-form.component'

export const routes: Routes = [
    //Rota 1: Redirecionamento da raiz
    { path: '', redirectTo: '/heroes', pathMatch: 'full' },

    //Rota 2: Lista de Heróis
    { path: 'heroes', component: HeroListComponent },

    //Rota 3: Formulário de Criação
    { path: 'heroes/new', component: HeroFormComponent },

    //Rota 4: Formulário d Edição
    { path: 'heroes/edit/:id', component: HeroFormComponent }
];
