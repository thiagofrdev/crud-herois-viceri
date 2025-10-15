import { Component, Input, OnInit, OnChanges, Output, EventEmitter } from '@angular/core';
import { Hero } from '../../models/hero.model';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { HeroService } from '../../services/hero.service';
import { Superpoder } from '../../models/superpoder.model';

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
  allSuperpowers: Superpoder[] = [];

  get superpowersFormArray() {
    return this.heroForm.controls['superpoderes'] as FormArray;
  }

  constructor(private fb: FormBuilder, private heroService: HeroService) {
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

  // ngOnChanges(): void {
  //   this.heroForm.reset();
  //   this.superpowersFormArray.clear();
    
  //   this.allSuperpowers.forEach(() => 
  //     this.superpowersFormArray.push(new FormControl(false))
  //   );

  //    if (this.hero) {
  //     const formattedDate = this.hero.dataNascimento.toString().split('T')[0];

  //     const heroDataForForm = {
  //       ...this.hero,
  //       dataNascimento: formattedDate,
  //       altura: parseFloat(this.hero.altura.toFixed(2)),
  //       peso: parseFloat(this.hero.peso.toFixed(2))
  //     };

  //     this.heroForm.patchValue(heroDataForForm);
  //     this.checkBoxSuperpowers();
  //   }
  // }
  ngOnChanges(): void {
    if (this.hero) {
      this.fillFormWithHeroData();
    } else {
      this.heroForm.reset();
    }
  }

  onSubmit(): void {
    const formValue = this.heroForm.value;

    const selectedSuperpowerIds = formValue.superpoderes
      .map((checked: boolean, i: number) => checked ? this.allSuperpowers[i].id : null)
      .filter((id: number | null) => id !== null);

    const heroDataPayload = {
      nome: formValue.nome,
      nomeHeroi: formValue.nomeHeroi,
      dataNascimento: formValue.dataNascimento,
      altura: formValue.altura,
      peso: formValue.peso,
      superpoderesIds: selectedSuperpowerIds
    };

    this.save.emit(heroDataPayload);
  }

  ngOnInit(): void {
    this.heroService.getSuperpowers().subscribe(sp => {
      this.allSuperpowers = sp;
      this.superpowersFormArray.clear();
      this.allSuperpowers.forEach(() => 
        this.superpowersFormArray.push(new FormControl(false))
      );
      this.checkBoxSuperpowers();
    });
  }

  private checkBoxSuperpowers(): void {
    if (this.hero && this.allSuperpowers.length > 0) {
      this.allSuperpowers.forEach((power, index) => {
        if (this.hero?.superpoderes.some(heroPower => heroPower.id === power.id)) {
          this.superpowersFormArray.at(index).setValue(true);
        }
      });
    }
  }

  private fillFormWithHeroData(): void {
    if (!this.hero) return;

    const formattedDate = new Date(this.hero.dataNascimento).toISOString().split('T')[0];

    this.heroForm.patchValue({
      id: this.hero.id,
      nome: this.hero.nome,
      nomeHeroi: this.hero.nomeHeroi,
      dataNascimento: formattedDate,
      altura: this.hero.altura,
      peso: this.hero.peso,
    });

    this.checkBoxSuperpowers();
  }
}
