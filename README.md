# Latin Decoder 

The [*Latin Decoder*](https://latindecoder.com) is the first ever digital tool designed to process and integrate fragmentary Latin texts such as manuscripts and epigraphs. By simply typing a fragmentary Latin word or a group of words including missing letters (*e*.*g*., pec---a) in the search bar, users can look up all its possible textual integrations, as attested in the entire corpus of extant Latin literature and epigraphy.

Usually, it is reasonably easy to identify the number of characters of a fragmentary word in a manuscript or an inscription through the analysis of the handwriting and the space that extant characters occupy on the page or stone. However, it is difficult to think about the possible integrations that would match a specific series of letters and spaces in a fragmentary Latin text, especially when a non-native speaker of Latin looks for a so-called *lectio difficilior* (*i*.*e*., a more specific and less banal textual integration).

Addressing this need, the *Latin Decoder* leverages original algorithms and the data provided by the *Latin Diachronic Database* (https://github.com/WizardOfMenlo/LatinDiachronicDatabase; See [Spinelli 2021: 12–14](https://journals.ub.uni-heidelberg.de/index.php/dco/article/view/76079/72579)) to enable users to consider all the possible integrations for a fragmentary Latin word or group of words. Specifically, the programme processes a large textual corpus yielding some 9,500,000 words, and covering the works of 307 authors (from the IV century BCE to the VI century CE) which was assembled using different opensource textual databases available online such as *Perseus*, the *PHI Database*, *Corpus Corporum* and the *Bibliotheca Augustana*. Moreover, thanks to the kind permission of Prof. Manfred Clauss, the *Latin Decoder Database* now includes the entire corpus of Latin epigraphs as recorded in the *Corpus Inscriptionum Latinarum*. When a fragmentary word is fed into the system, original algorithms parse the textual corpus in a few seconds and compile a list of attested word-forms that match the query before eliminating duplicates automatically. In so doing, the programme boosts the linguistic capabilities of the human mind by providing scholars with an accurate list of possible integrations that may also include very rare terms that are attested only a few times in extant Latin literature and epigraphs.

## Acknowledgements

The *Latin Decoder* was invented, designed and co-developed by Tommaso Spinelli (University of Manchester), with the technical assistance of Giacomo Fenzi (University of Zurich, ETH) for the development of the parsing and lemmatising technology, and Alexandros Michael (University of St Andrews) for the development of the web application.

The developers would like to express their gratitude to the University of Manchester for hosting this programme, and to Anja Le Blanc and Theresa Teng for facilitating the realisation of this project.

The Diachronic Latin Database (https://risweb.st-andrews.ac.uk/portal/en/datasets/the-latin-diachronic-database-project(05bf041f-9654-4173-8c8a-b93a2efa0926).html) used by the *Latin Decoder* was developed by Tommaso Spinelli and Giacomo Fenzi within the *Latine Loquamur* project (https://github.com/latineloquamur?tab=repositories), which was awarded funding by the University of St Andrews (22/03/2018; Grant 690039408), and perfected by Tommaso Spinelli during his Postdoctoral Fellowship at the *Pontificium Institutum Altioris Latinitatis* of the Salesian University of Rome.

## Projects

- [LatinDecoder](LatinDecoder) - This is the [Web Application](https://latindecoder.com) (.NET Core 3.1 Blazor Server) project.
- [LatinDecoderDAL](LatinDecoderDAL) - This is the library that implements the data access and word-matching features.
- [LatinDecoderTest](LatinDecoderTest) - This is the unit testing project used during development.
