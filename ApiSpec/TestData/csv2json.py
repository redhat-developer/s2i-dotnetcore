#!/c/Python27/python

import sys, csv, json
import os, os.path
from itertools import groupby

def hello(name="woot"):
    print "Hello, %s!" % name

def get_field_names(filename):
    input_file = open(filename)
    gdoc = csv.reader(input_file)

    # Get the 1st line, assuming it contains the column titles
    fieldnames = gdoc.next()

    input_file.close()

    return fieldnames

def process_file(filename):
    # Get the fieldnames
    fieldnames = get_field_names(filename)

    input_file = open(filename)
    gdoc = csv.reader(input_file)

    # skip the 1st line, assuming it contains the column titles
    gdoc.next()

    # Get the total number of columns
    fieldnames_len = len(fieldnames)

    # print "Fieldnames: %s" % fieldnames

    data = [] # Empty list
    i = 0

    for row in gdoc:

        if row[0].startswith("-"):
            continue

        # Add an empty dict to the list
        data.append({})

        for j in range(0, len(row)):
            # Skip columns with fieldnames starting with !
            if fieldnames[j].startswith("!"):
                continue

            value = row[j]

            attribute = fieldnames[j]

            if value.startswith("rg:"):
                command = value.strip("rg:")
                value = eval(command)

            data[i][fieldnames[j]] = value

        # What if the last few cells are empty ? There may not be commas
        for j in range(len(row), fieldnames_len):
            data[i][fieldnames[j]] = ""

        i = i + 1

    input_file.close()

    # clean up
    return data

def named_datasets(name, dataset_defs):

    datasets = {}
    data = []

    datasets[name] = data

    for dataset_def in dataset_defs:
        filename, dataset_name = dataset_def
        current_dataset = dataset(filename, dataset_name)
        data.append(current_dataset)

    return datasets

def dataset(filename, dataset_name):
    all_data = process_file(filename)
    datasets = make_datasets(all_data)
    return datasets[dataset_name]

def child(filename, element_name):
    return dataset(filename, element_name).pop()

def exclude_fields(data, excluded_field_names=['File']):
    for excluded_field in excluded_field_names:
        if excluded_field in data:
            del data[excluded_field]

def make_datasets(data):
    # function to use to extract the 'File' attribute from a row; used for sorted() and groupby()
    keyfunc = lambda x: x['File']
    # sort the list of rows using the result of keyfunc as the key
    data = sorted(data, key=keyfunc)

    datasets = {}
    # group the now sorted list of rows by the value of File, as provided by keyfunc and turn the groupby into a regular dict
    for group_name, group_data in groupby(data, keyfunc):
        # print "Group name: %s" % group_name

        # groupby is a generator, so we need to convert it into a concrete list
        group_data_as_list = list(group_data)
        datasets[group_name] = group_data_as_list

        # strip out the excluded attibutes (eg. 'File') so they are not included in the JSON
        for record in group_data_as_list:
            exclude_fields(record)

    return datasets

def output_dataset(entity_name, dataset_name, dataset, excluded_field_names=['File'], flat=False):
    # for top-level files, we only have one record per output file, so we don't want an array, so twiddle things so we won't output a JSON array
    if not flat:
        # print 'pop!'
        dataset = dataset.pop()

    # serialize the data to a json string
    group_data_as_json = json.dumps(dataset, sort_keys=True, indent=4, separators=(',', ': '))

    # output_dir = "../out"
    output_dir = "../%s" % (entity_name)
    if not os.path.exists(output_dir):
        os.mkdir(output_dir)

    # open an output file, naming it <input_file_prefix>_<group_name>.m4
    group_data_file = open("%s/%s_%s.%s" % (output_dir, entity_name, dataset_name, "json"), 'w')
    group_data_file.write(group_data_as_json)
    # clean up
    group_data_file.close()

if len(sys.argv) == 1:
    print "1 argument for filename required"
    sys.exit()
input_filename = sys.argv[1]

flat = False

if len(sys.argv) == 3:
    flat = sys.argv[2] in ['True', 'true', '1', 't', 'y', 'yes', 'yeah', 'yup', 'certainly', 'uh-huh']

if os.path.exists(input_filename):
        print 'Processing input file \'%s\'.' % input_filename

dir_name_part, file_name_part = os.path.split(input_filename)
# print "Dir: %s" % dir_name_part
os.chdir(dir_name_part)
entity_name = file_name_part.split(".")[0]
# print "Entity name: %s" % entity_name
data_dicts = process_file(file_name_part)
datasets = make_datasets(data_dicts)

for dataset_name, dataset_data in datasets.iteritems():
    output_dataset(entity_name, dataset_name, dataset_data, None, flat)
