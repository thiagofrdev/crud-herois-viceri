import { Component, Input, OnInit, OnChanges, Output, EventEmitter } from '@angular/core';
import { Hero } from '../../models/hero.model';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-hero-form-ui',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './hero-form-ui.component.html',
  styleUrl: './hero-form-ui.component.scss'
})
export class HeroFormUiComponent {
  @Input() hero?: Hero;
  @Output() save = new EventEmitter<any>();

  heroForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.heroForm = this.fb.group({
      id: [null],
      nome: ['', Validators.required],
      nomeHeroi: ['', Validators.required],
      dataNascimento: [null, Validators.required],
      altura: [0, Validators.required],
      peso: [0, Validators.required],
      superpoderes: this.fb.array([], Validators.required)
    });
  }

  ngOnChanges(): void {
    if (this.hero) {
      this.heroForm.patchValue(this.hero);
    }
  }
  
  onSubmit(): void {
    this.save.emit(this.heroForm.value);
  }
}
